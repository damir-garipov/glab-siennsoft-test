import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { EditDialogData } from '../contracts/edit-dialog-data';

//EntityEditDialog
@Component({
    templateUrl: './entity-edit.dialog.html'
})
export class EntityEditDialog{
    constructor(public dialogRef: MatDialogRef<EntityEditDialog>,
        @Inject(MAT_DIALOG_DATA) public data: EditDialogData){ }
    
    onNoClick(): void {
        this.dialogRef.close();
    }
}

//Promt Dialog
@Component({
    templateUrl: './prompt.dialog.html'
})
export class PromptDialog{
    constructor(public dialogRef: MatDialogRef<PromptDialog>,
        @Inject(MAT_DIALOG_DATA) public data: EditDialogData){ }
}