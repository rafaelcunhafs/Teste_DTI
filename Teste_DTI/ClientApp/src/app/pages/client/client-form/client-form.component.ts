import { Component, Inject, OnInit, Optional } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Client } from "../../../models/client.model";
import { client_form_validation_messages } from "../../../shared/validators/client-form.validator";

@Component({
  selector: 'client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {

  public clientForm: FormGroup;
  public client: Client;
  public errorMessages: Object = client_form_validation_messages;

  constructor(
    private _formBuilder: FormBuilder,
    private _dialogRef: MatDialogRef<ClientFormComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Client
  ) {
    this.client = data == null ? {} as Client : data;
    console.log(this.client);
  }

  ngOnInit() {
    this.clientForm = this._formBuilder.group({
      id: [this.client.id],
      nome: [this.client.nome, Validators.required],
      endereco: [this.client.endereco, Validators.required],
      celular: [this.client.celular, Validators.required],
      email: new FormControl(this.client.email, Validators.compose([Validators.required, Validators.email])),
      cpf: [this.client.cpf, Validators.required]
    });
  }

  createClient() {
    let data = this.clientForm.getRawValue();
    delete data['id'];
    console.log(data);
    this._dialogRef.close(data);
  }

  editClient() {
    this._dialogRef.close(this.clientForm.getRawValue());
  }

  close() {
    this._dialogRef.close();
  }
}
