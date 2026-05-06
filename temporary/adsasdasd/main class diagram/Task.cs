
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Task : ILinkedToAnyClient {

    public Task() {
    }

    public GUID id;

    public string title;

    public string? description;

    public TaskPriority priority;

    public TaskStatus status;

    public datetime enddate;

    public datetime startDate;

    public datetime? completedAt;



}