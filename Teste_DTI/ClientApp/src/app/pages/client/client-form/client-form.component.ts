import { Component, Inject, OnInit, Optional } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Client } from "../../../models/client.model";

@Component({
  selector: 'client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {

  clientForm: FormGroup;
  client: Client;

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
      endereco: [this.client.endereco],
      celular: [this.client.celular],
      email: [this.client.email],
      cpf: [this.client.cpf]
    });
  }

  createClient() {
    let data = this.clientForm.getRawValue();
    delete data['id'];
    this._dialogRef.close(data);
  }

  editClient() {
    this._dialogRef.close(this.clientForm.getRawValue());
  }

  close() {
    this._dialogRef.close();
  }
}
