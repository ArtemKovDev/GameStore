using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICartLineRepository CartLineRepository { get; }

        ICommentRepository CommentRepository { get; }

        IGameGenreRepository GameGenreRepository { get; }

        IGameRepository GameRepository { get; }

        IGenreRepository GenreRepository { get; }

        IOrderRepository OrderRepository { get; }

        IPaymentTypeRepository PaymentTypeRepository { get; }

        IRegisteredUserRepository RegisteredUserRepository { get; }

        Task<int> SaveAsync();
    }
}
