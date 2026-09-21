import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { Incident } from '../../core/models/incident';
import { IncidentService } from '../../core/services/incident.service';

@Component({
  selector: 'app-incidents',
  standalone: true,
  imports: [
    CommonModule,
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
export class Incidents implements OnInit {

  displayedColumns = [
    'incident',
    'source',
    'risk',
    'severity',
    'status',
    'time'
  ];

  incidents: Incident[] = [];
  filteredIncidents: Incident[] = [];

  constructor(private incidentService: IncidentService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.loadIncidents();
  }

  loadIncidents(): void {
    this.incidentService.getIncidents().subscribe({
      next: (data) => {
        this.incidents = data;
        this.filteredIncidents = [...data];
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Failed to load incidents:', error);
      }
    });
  }

  searchIncidents(event: Event): void {
    const value = (event.target as HTMLInputElement).value
      .toLowerCase()
      .trim();

    this.filteredIncidents = this.incidents.filter(incident =>
      incident.title.toLowerCase().includes(value) ||
      incident.source.toLowerCase().includes(value) ||
      incident.severity.toLowerCase().includes(value) ||
      incident.status.toLowerCase().includes(value)
    );
  }
}