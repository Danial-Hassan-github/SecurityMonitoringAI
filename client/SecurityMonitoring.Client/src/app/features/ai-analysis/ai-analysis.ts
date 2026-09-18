import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-ai-analysis',
  standalone: true,
  imports: [
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatChipsModule
  ],
  templateUrl: './ai-analysis.html',
  styleUrl: './ai-analysis.css'
})
export class AiAnalysis {

  analyses = [
    {
      event: 'Brute Force Detected',
      source: '192.168.1.25',
      severity: 'Critical',
      confidence: 94,
      status: 'Analyzed',
      time: '18:19:12'
    },
    {
      event: 'Suspicious API Request',
      source: '10.0.0.42',
      severity: 'High',
      confidence: 87,
      status: 'Analyzed',
      time: '18:16:48'
    },
    {
      event: 'Privilege Escalation',
      source: '10.0.0.15',
      severity: 'Critical',
      confidence: 91,
      status: 'Analyzed',
      time: '18:08:42'
    },
    {
      event: 'Port Scan Detected',
      source: '172.16.0.18',
      severity: 'High',
      confidence: 82,
      status: 'Pending',
      time: '18:14:21'
    }
  ];

  selectedAnalysis = this.analyses[0];

  selectAnalysis(analysis: any): void {
    this.selectedAnalysis = analysis;
  }

  runAnalysis(): void {
    console.log('AI analysis started');
  }
}