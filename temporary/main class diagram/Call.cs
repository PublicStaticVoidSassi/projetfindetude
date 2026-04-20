
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Call : ILinkedToAnyClient {

    public Call() {
    }

    public GUID id;

    public string subject;

    public datetime callTime;

    public float duration;

    public datetime? closedAt;

    public string? description;

    public CallStatus status;

    public CallDirection direction;


}