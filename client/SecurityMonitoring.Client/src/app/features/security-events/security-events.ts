import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-security-events',
  standalone: true,
  imports: [
    MatCardModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatChipsModule
  ],
  templateUrl: './security-events.html',
  styleUrl: './security-events.css'
})
export class SecurityEvents {

  displayedColumns = [
    'time',
    'event',
    'source',
    'user',
    'severity'
  ];

  events = [
    {
      time: '18:21:34',
      event: 'Failed Login Attempt',
      source: '192.168.1.25',
      user: 'john.doe',
      severity: 'Medium'
    },
    {
      time: '18:19:12',
      event: 'Brute Force Detected',
      source: '192.168.1.25',
      user: 'admin',
      severity: 'Critical'
    },
    {
      time: '18:16:48',
      event: 'Suspicious API Request',
      source: '10.0.0.42',
      user: 'api-user',
      severity: 'High'
    },
    {
      time: '18:14:21',
      event: 'Port Scan Detected',
      source: '172.16.0.18',
      user: 'unknown',
      severity: 'High'
    },
    {
      time: '18:11:05',
      event: 'Successful Login',
      source: '192.168.1.80',
      user: 'alice.smith',
      severity: 'Low'
    },
    {
      time: '18:08:42',
      event: 'Privilege Escalation',
      source: '10.0.0.15',
      user: 'service-account',
      severity: 'Critical'
    },
    {
      time: '18:05:17',
      event: 'Failed Login Attempt',
      source: '192.168.1.44',
      user: 'mike.ross',
      severity: 'Medium'
    }
  ];

  filteredEvents = [...this.events];

  searchEvents(event: Event) {
    const value = (event.target as HTMLInputElement).value
      .toLowerCase()
      .trim();

    this.filteredEvents = this.events.filter(item =>
      item.event.toLowerCase().includes(value) ||
      item.source.toLowerCase().includes(value) ||
      item.user.toLowerCase().includes(value) ||
      item.severity.toLowerCase().includes(value)
    );
  }

}