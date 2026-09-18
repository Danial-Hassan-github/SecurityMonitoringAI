import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [
    FormsModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatSlideToggleModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule
  ],
  templateUrl: './settings.html',
  styleUrl: './settings.css'
})
export class Settings {

  notifications = true;
  emailAlerts = false;
  autoRefresh = true;
  aiAnalysis = true;

  refreshInterval = '30';
  severityThreshold = 'High';

  apiEndpoint = 'https://localhost:7015/api';

  saveSettings(): void {
    console.log('Settings saved');
  }

  resetSettings(): void {
    this.notifications = true;
    this.emailAlerts = false;
    this.autoRefresh = true;
    this.aiAnalysis = true;

    this.refreshInterval = '30';
    this.severityThreshold = 'High';

    this.apiEndpoint = 'https://localhost:7015/api';
  }
}