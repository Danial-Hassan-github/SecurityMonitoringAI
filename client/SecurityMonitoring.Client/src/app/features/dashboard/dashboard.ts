import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {
  stats = [
    { label: 'Critical Incidents', value: 4, type: 'critical' },
    { label: 'High Risk Incidents', value: 12, type: 'high' },
    { label: 'Security Events', value: 843, type: 'events' },
    { label: 'Suspicious IPs', value: 27, type: 'suspicious' }
  ];

  incidents = [
    {
      title: 'Brute Force Attack',
      source: '192.168.1.25',
      risk: 92,
      severity: 'Critical',
      time: '2 min ago'
    },
    {
      title: 'Suspicious API Activity',
      source: '10.0.0.42',
      risk: 71,
      severity: 'High',
      time: '8 min ago'
    },
    {
      title: 'Port Scan Detected',
      source: '172.16.0.18',
      risk: 68,
      severity: 'High',
      time: '15 min ago'
    },
    {
      title: 'Failed Login Attempts',
      source: '192.168.1.80',
      risk: 15,
      severity: 'Low',
      time: '24 min ago'
    }
  ];
}