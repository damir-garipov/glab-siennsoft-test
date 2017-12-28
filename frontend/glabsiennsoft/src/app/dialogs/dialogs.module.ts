import { NgModule } from '@angular/core';
import { EntityEditDialog, PromptDialog } from './dialogs'
import { MatModule } from '../mat.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations:[
        EntityEditDialog,
        PromptDialog
    ],
    entryComponents:[
        EntityEditDialog,
        PromptDialog
    ],
    imports:[
        BrowserModule,
        FormsModule,
        MatModule
    ],
    // exports:[
    //     EntityEditDialog,
    //     PromptDialog    
    // ]
})
export class DialogsModule{

}