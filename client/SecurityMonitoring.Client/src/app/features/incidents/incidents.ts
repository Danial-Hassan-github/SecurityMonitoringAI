import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-incidents',
  standalone: true,
  imports: [
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './incidents.html',
  styleUrl: './incidents.css'
})
export class Incidents {

  displayedColumns = [
    'incident',
    'source',
    'risk',
    'severity',
    'status',
    'time'
  ];

  incidents = [
    {
      incident: 'Brute Force Attack',
      source: '192.168.1.25',
      risk: 92,
      severity: 'Critical',
      status: 'Open',
      time: '2 min ago'
    },
    {
      incident: 'Suspicious API Activity',
      source: '10.0.0.42',
      risk: 71,
      severity: 'High',
      status: 'Investigating',
      time: '8 min ago'
    },
    {
      incident: 'Port Scan Detected',
      source: '172.16.0.18',
      risk: 68,
      severity: 'High',
      status: 'Open',
      time: '15 min ago'
    },
    {
      incident: 'Privilege Escalation',
      source: '10.0.0.15',
      risk: 88,
      severity: 'Critical',
      status: 'Investigating',
      time: '19 min ago'
    },
    {
      incident: 'Multiple Failed Logins',
      source: '192.168.1.44',
      risk: 54,
      severity: 'Medium',
      status: 'Open',
      time: '31 min ago'
    },
    {
      incident: 'Unusual Login Location',
      source: '192.168.1.80',
      risk: 32,
      severity: 'Low',
      status: 'Resolved',
      time: '1 hour ago'
    }
  ];

  filteredIncidents = [...this.incidents];

  searchIncidents(event: Event) {

    const value = (event.target as HTMLInputElement).value
      .toLowerCase()
      .trim();

    this.filteredIncidents = this.incidents.filter(incident =>
      incident.incident.toLowerCase().includes(value) ||
      incident.source.toLowerCase().includes(value) ||
      incident.severity.toLowerCase().includes(value) ||
      incident.status.toLowerCase().includes(value)
    );
  }
}