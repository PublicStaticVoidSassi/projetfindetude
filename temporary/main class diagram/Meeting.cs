
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Meeting : ILinkedToAnyClient {

    public Meeting() {
    }

    public GUID id;

    public string subject;

    public string description;

    public datetime startsat;

    public datetime endsat;

    public string location;

    public MeetingStatus status;


}