using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncChatNew.Dtos;
using Microsoft.AspNet.SignalR;

namespace AsyncChatNew.Hubs
{
    public class TestChatHub : Hub
    {
        public static List<UserDto> Users = new List<UserDto>();

        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (Users.Any(x => x.ConnectionId == id))
            {
                return;
            }
            Users.Add(new UserDto { ConnectionId = id, Name = userName });

            // Посылаем сообщение текущему пользователю
            Clients.Caller.onConnected(id, userName, Users);

            // Посылаем сообщение всем пользователям, кроме текущего
            Clients.AllExcept(id).onNewUserConnected(id, userName);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}