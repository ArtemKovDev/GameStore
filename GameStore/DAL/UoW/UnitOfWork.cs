using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private CartLineRepository cartLineRepository;
        private CommentRepository commentRepository;
        private GameGenreRepository gameGenreRepository;
        private GameRepository gameRepository;
        private GenreRepository genreRepository;
        private OrderRepository orderRepository;
        private PaymentTypeRepository paymentTypeRepository;
        private RegisteredUserRepository registeredUserRepository;

        public UnitOfWork(DbContextOptions<ApplicationDbContext> options)
        {
            db = new ApplicationDbContext(options);
        }

        public ICartLineRepository CartLineRepository
        {
            get
            {
                if (cartLineRepository == null)
                    cartLineRepository = new CartLineRepository(db);
                return cartLineRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IGameGenreRepository GameGenreRepository
        {
            get
            {
                if (gameGenreRepository == null)
                    gameGenreRepository = new GameGenreRepository(db);
                return gameGenreRepository;
            }
        }

        public IGameRepository GameRepository
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IPaymentTypeRepository PaymentTypeRepository
        {
            get
            {
                if (paymentTypeRepository == null)
                    paymentTypeRepository = new PaymentTypeRepository(db);
                return paymentTypeRepository;
            }
        }

        public IRegisteredUserRepository RegisteredUserRepository
        {
            get
            {
                if (registeredUserRepository == null)
                    registeredUserRepository = new RegisteredUserRepository(db);
                return registeredUserRepository;
            }
        }

        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }

        private bool isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                isDisposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
