using FSPE.API.DAL.Models;
using System;

namespace FSPE.API.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly PoolManagerContext _context = new PoolManagerContext();
        private GenericRepository<Pool> _poolRepository;
        private GenericRepository<Game> _gameRepository;
        private GenericRepository<Square> _squareRepository;
        private GenericRepository<Team> _teamRepository; 


        public GenericRepository<Pool> PoolRepository
        {
            get { return _poolRepository ?? (_poolRepository = new GenericRepository<Pool>(_context)); }
        }

        public GenericRepository<Game> GameRepository
        {
            get { return _gameRepository ?? (_gameRepository = new GenericRepository<Game>(_context)); }
        }

        public GenericRepository<Team> TeamRepository
        {
            get { return _teamRepository ?? (_teamRepository = new GenericRepository<Team>(_context)); }
        }

        public GenericRepository<Square> SquareRepository
        {
            get { return _squareRepository ?? (_squareRepository = new GenericRepository<Square>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}