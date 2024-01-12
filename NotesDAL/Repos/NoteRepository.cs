using NotesDAL.EF;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace NotesDAL.Repos
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NoteDbContext _db;

        public NoteRepository()
        {
            _db = new NoteDbContext();
        }

        public IEnumerable<Note> GetAll()
        {
           return _db.Notes.ToList();
        }

        public Note Get(Guid id)
        {
            return _db.Notes.Find(id);
        }

        public void Create(Note item)
        {
            _db.Notes.Add(item);
        }

        public void Update(Note item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Note note = _db.Notes.Find(id);
            if (note != null)
                _db.Notes.Remove(note);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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
