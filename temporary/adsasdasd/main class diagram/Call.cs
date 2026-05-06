
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Call : ILinkedToAnyClient {

    public Call() {
    }

    public GUID id;

    public string subject;

    public string? description;

    public datetime callTime;

    public float duration;

    public datetime? closedAt;

    public CallStatus status;

    public CallDirection direction;


}