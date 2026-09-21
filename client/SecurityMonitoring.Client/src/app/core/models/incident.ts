export interface Incident {
  id: number;
  title: string;
  description: string;
  source: string;
  riskScore: number;
  severity: string;
  status: string;
  createdAt: string;
  resolvedAt: string | null;
}