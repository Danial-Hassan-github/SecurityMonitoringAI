export interface SecurityEvent {
  id: number;
  timestamp: string;
  sourceType: string;
  sourceIp: string;
  destinationIp: string | null;
  sourcePort: number | null;
  destinationPort: number | null;
  protocol: string | null;
  eventId: number | null;
  eventType: string;
  severity: string;
  message: string;
  status: string;
}