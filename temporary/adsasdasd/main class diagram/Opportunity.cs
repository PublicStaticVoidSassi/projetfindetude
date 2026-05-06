
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Opportunity : ILinkedToAnyClient {

    public Opportunity() {
    }

    public GUID id;

    public string name;

    public string? description;

    public Money Amount;

    public Currency currency;

    public OpportunityStage stage;

    public OpportunityType type;

    public SaleStage saleStage;

    public short probability;

    public string? nextStep;

    public date? closedAt;
















}