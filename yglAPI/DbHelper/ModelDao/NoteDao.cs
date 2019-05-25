using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models;

namespace yglAPI.DbHelper.ModelDao
{
    public class NoteDao :  DaoBase<Note, Int32>
    {
        public int? insertNote(Note note)
        {
            return this.Insert(note);
        }

        public int deleteNote(int id)
        {
            return this.Delete(id);
        }

        public Note getNote(int id)
        {
            return this.Get(id);
        }
    }
}
