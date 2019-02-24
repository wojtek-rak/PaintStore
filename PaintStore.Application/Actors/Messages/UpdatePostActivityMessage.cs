using PaintStore.Persistence;

namespace PaintStore.Application.Actors.Messages
{
    public class UpdatePostActivityMessage
    {
        public IDBContextCreate IDBContextCreate { get; }
        public UpdatePostActivityMessage()
        {
        }

        public UpdatePostActivityMessage(IDBContextCreate idbContextCreate)
        {
            IDBContextCreate = idbContextCreate;
        }

    }
}
