
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Note : ILinkedToAnyClient {

    public Note() {
    }

    public GUID id;

    public string subject;

    public string content;

}