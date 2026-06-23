
export interface AccountAnalytics extends BaseAnalytics {
}

export interface AnalyticsDto {
  lead?: LeadAnalytics;
  account?: AccountAnalytics;
  contact?: ContactAnalytics;
  opportunity?: OpportunityAnalytics;
}

export interface BaseAnalytics {
  total?: number;
}

export interface ContactAnalytics extends BaseAnalytics {
  active?: number;
}

export interface LeadAnalytics extends BaseAnalytics {
  converted?: number;
}

export interface OpportunityAnalytics extends BaseAnalytics {
  won?: number;
  lost?: number;
  dzdincome?: number;
  eurincome?: number;
  usdincome?: number;
}
