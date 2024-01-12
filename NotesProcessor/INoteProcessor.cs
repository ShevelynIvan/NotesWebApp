using Contracts;

namespace NotesProcessor
{
    public interface INoteProcessor
    {
        IEnumerable<Note> GetAll();
        Note Get(Guid id);
        void Create(Note item);
        void Update(Note item);
        void Delete(Guid id);
        IEnumerable<Note> SortNotesByPriority(IEnumerable<Note> notes);
    }
}
