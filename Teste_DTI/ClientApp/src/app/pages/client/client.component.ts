import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';

import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { ClientService } from '../../services/client/client.service';
import { Client } from '../../models/client.model';
import { ClientFormComponent } from './client-form/client-form.component';
import { error } from '@angular/compiler/src/util';
import { ConfirmDialogComponent } from '../../shared/components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit, AfterViewInit {

  selectedClientsIds: Set<string> = new Set<string>();
  displayedColumns: string[] = ['checkboxes', 'nome', 'endereco', 'celular', 'email', 'cpf', 'actions'];
  dataSource = new MatTableDataSource<Client>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  constructor(
    private _clientService: ClientService,
    private _snackBar: MatSnackBar,
    private _dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getClients();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public getClients() {
    this._clientService.get().subscribe(clients => this.dataSource.data = clients as Client[]);
  }

  public createClient(): void {
    const dialogRef = this._dialog.open(ClientFormComponent, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe((client: Client) => {
      if (client != null)
        this._clientService.create(client)
          .subscribe(
            (item: Client) => {
              this.dataSource.data.push(item);
              this.table.renderRows();
            },
            error => this._snackBar.open(error.error, "Ok")
          );
    });
  }

  public deleteClient(client: Client) {
    const confirmDialog = this._dialog.open(ConfirmDialogComponent, {
      data: {
        title: 'Confirm Remove Client',
        message: 'Are you sure, you want to remove this client: ' + client.nome
      }
    });

    confirmDialog.afterClosed().subscribe(result => {
      if (result === true)
        this._clientService.delete(client.id)
          .subscribe(
            (client: Client) => this.dataSource.data = this.dataSource.data.filter((item: Client) => {
              return item.id != client.id;
            }),
            error => this._snackBar.open(error.error, "Ok")
          );
    });
  }

  public deleteSelectedClients() {
    const confirmDialog = this._dialog.open(ConfirmDialogComponent, {
      data: {
        title: 'Delete Selected Clients',
        message: 'Are you sure, you want to remove all selected Clients?'
      }
    });

    confirmDialog.afterClosed().subscribe(result => {
      if (result !== true)
        return;

      this.selectedClientsIds.forEach((id) => {
        this._clientService.delete(id)
          .subscribe(
            (client: Client) => this.dataSource.data = this.dataSource.data.filter((item: Client) => {
              return item.id != client.id;
            }),
            error => this._snackBar.open(error.error, "Ok")
          );
      });

    });
  }

  public editClient(client: Client): void {
    const dialogRef = this._dialog.open(ClientFormComponent, {
      width: '500px',
      data: client
    });

    dialogRef.afterClosed().subscribe((client: Client) => {
      if (client != null)
        this._clientService.edit(client)
          .subscribe(
            (editedClient: Client) => {
              const index = this.dataSource.data.findIndex(item => item.id === editedClient.id);
              this.dataSource.data[index] = editedClient;
              this.table.renderRows();
            },
            error => this._snackBar.open(error.error, "Ok")
          );
    });
  }

  public filterTable = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  public selectAllClients(toogle: boolean) {
    this.selectedClientsIds.clear();

    if (toogle)
      this.dataSource.filteredData.forEach(client => this.selectedClientsIds.add(client.id));
  }

  public onClientClick(id: string) {
    if (this.selectedClientsIds.has(id))
      this.selectedClientsIds.delete(id);
    else
      this.selectedClientsIds.add(id);
  }
}
