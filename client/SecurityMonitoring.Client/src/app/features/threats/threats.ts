import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

interface Threat {
  threat: string;
  category: string;
  source: string;
  severity: string;
  confidence: number;
  occurrences: number;
  lastDetected: string;
}

@Component({
  selector: 'app-threats',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './threats.html',
  styleUrl: './threats.css'
})
export class Threats {

  searchTerm = '';

  displayedColumns = [
    'threat',
    'category',
    'source',
    'severity',
    'confidence',
    'occurrences',
    'lastDetected'
  ];

  threats: Threat[] = [
    {
      threat: 'Brute Force Attack',
      category: 'Credential Attack',
      source: '192.168.1.25',
      severity: 'Critical',
      confidence: 96,
      occurrences: 42,
      lastDetected: '2 min ago'
    },
    {
      threat: 'Port Scanning',
      category: 'Reconnaissance',
      source: '172.16.0.18',
      severity: 'High',
      confidence: 89,
      occurrences: 18,
      lastDetected: '15 min ago'
    },
    {
      threat: 'Suspicious API Activity',
      category: 'Application Attack',
      source: '10.0.0.42',
      severity: 'High',
      confidence: 82,
      occurrences: 27,
      lastDetected: '8 min ago'
    },
    {
      threat: 'Privilege Escalation',
      category: 'Privilege Abuse',
      source: '10.0.0.15',
      severity: 'Critical',
      confidence: 91,
      occurrences: 7,
      lastDetected: '19 min ago'
    },
    {
      threat: 'Credential Stuffing',
      category: 'Credential Attack',
      source: '192.168.1.44',
      severity: 'Medium',
      confidence: 74,
      occurrences: 13,
      lastDetected: '31 min ago'
    },
    {
      threat: 'Unusual Login Location',
      category: 'Account Anomaly',
      source: '192.168.1.80',
      severity: 'Low',
      confidence: 68,
      occurrences: 5,
      lastDetected: '1 hour ago'
    }
  ];

  filteredThreats: Threat[] = [...this.threats];

  filterThreats(): void {
    const term = this.searchTerm.toLowerCase().trim();

    if (!term) {
      this.filteredThreats = [...this.threats];
      return;
    }

    this.filteredThreats = this.threats.filter(threat =>
      threat.threat.toLowerCase().includes(term) ||
      threat.category.toLowerCase().includes(term) ||
      threat.source.toLowerCase().includes(term) ||
      threat.severity.toLowerCase().includes(term)
    );
  }
}