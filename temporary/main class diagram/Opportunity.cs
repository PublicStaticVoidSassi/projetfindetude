
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Opportunity : ILinkedToAnyClient {

    public Opportunity() {
    }

    public GUID id;

    public string name;

    public Money value;

    public Currency currency;

    public OpportunityStage stage;

    public OpportunityType type;

    public short probability;

    public string? description;

    public date expectedClose;

    public date? actualClose;









}