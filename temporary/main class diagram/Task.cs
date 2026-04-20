
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Task : ILinkedToAnyClient {

    public Task() {
    }

    public GUID id;

    public string title;

    public datetime duedate;

    public datetime startDate;

    public TaskPriority priority;

    public TaskStatus status;

    public string? description;



}