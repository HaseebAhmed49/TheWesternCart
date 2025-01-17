import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-roles-modal',
  imports: [],
  templateUrl: './roles-modal.component.html',
  styleUrl: './roles-modal.component.scss'
})
export class RolesModalComponent {
  username = '';
  availableRoles: any[] = [];
  selectedRoles: any[] = [];
  roleSelections: { [role: string]: boolean } = {};
  constructor(public dialogRef: MatDialogRef<RolesModalComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
  }
  ngOnInit(): void {
    this.username = this.data.username;
    this.availableRoles = this.data.availableRoles;
    this.selectedRoles = this.data.selectedRoles;
    for (let role of this.availableRoles) {
      this.roleSelections[role] = this.selectedRoles.includes(role);
    }
  }
  updateChecked(role: string) {
    if (this.roleSelections[role]) {
      if (!this.selectedRoles.includes(role)) {
        this.selectedRoles.push(role);
      }
    } else {
      const index = this.selectedRoles.indexOf(role);
      if (index !== -1) {
        this.selectedRoles.splice(index, 1);
      }
    }
  }
}
