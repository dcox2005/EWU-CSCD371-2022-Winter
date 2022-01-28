using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture;

public enum Grade : Int64
{
    None,
    F = 1,
    D,
    C,
    B,
    A,
}

[Flags]
public enum FileAttribute : int
{
    None,
    Hidden,
    ReadOnly,
    System = Hidden & ReadOnly
}
