using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture;

public interface IStore : ISavable
{
    public void Persist(ISavable savable)
    {
        // pretending...
    }

    void Save(ISavable savable);
}
