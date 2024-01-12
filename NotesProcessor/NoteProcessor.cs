using NotesDAL.Repos;
using Contracts;

namespace NotesProcessor
{
    public class NoteProcessor : INoteProcessor
    {
        private readonly IRepository<Note> _repository;

        public NoteProcessor(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Note> GetAll()
        {
            return SortNotesByPriority(_repository.GetAll());
        }

        public Note Get(Guid id)
        {
            return _repository.Get(id);
        }

        public void Create(Note item)
        {
            _repository.Create(item);
            _repository.Save();
        }

        public void Update(Note item)
        {
            _repository.Update(item);
            _repository.Save();
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public IEnumerable<Note> SortNotesByPriority(IEnumerable<Note> notes)
        {
            return notes.OrderByDescending(x => x.Priority).ToList();
        }
    }
}
