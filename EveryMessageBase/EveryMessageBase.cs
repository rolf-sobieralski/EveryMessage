using System;

namespace EveryMessageBase
{
    public abstract class EveryMessageBase
    {
        public abstract void Login();
        public abstract void Logout();
        public abstract void SetStatus();
        public abstract void SendMessage();
        public abstract void GetMessage();
        public abstract void GetInfos();

    }
}
