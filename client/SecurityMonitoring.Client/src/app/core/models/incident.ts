export interface Incident {
  id: number;
  incident: string;
  description: string;
  source: string;
  riskScore: number;
  severity: string;
  status: string;
  createdAt: string;
  resolvedAt: string | null;
}