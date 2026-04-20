
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class softdeletable {

    public softdeletable() {
    }

    public bool isdeleted;

    public GUID deletedBy;

    public datetime datedeleted;



}