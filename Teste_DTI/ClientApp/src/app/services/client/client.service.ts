import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Constants } from "src/app/configs/constants";
import { Client } from '../../models/client.model';

@Injectable()
export class ClientService {

  constructor(
    private _http: HttpClient,
    private _constants: Constants
  ) { }

  public get() {
    const requestUrl = this._constants.API_ENDPOINT + "/api/clientes";
    return this._http.get(requestUrl);
  }

  public getById(id: string) {
    const requestUrl = this._constants.API_ENDPOINT + "/api/clientes/" + id;
    return this._http.get(requestUrl);
  }

  public create(client: Client) {
    const requestUrl = this._constants.API_ENDPOINT + "/api/clientes";
    return this._http.post(requestUrl, client);
  }

  public delete(id: string) {
    const requestUrl = this._constants.API_ENDPOINT + "/api/clientes/" + id;
    return this._http.delete(requestUrl);
  }

  public edit(client: Client) {
    const requestUrl = this._constants.API_ENDPOINT + "/api/clientes/" + client.id;
    return this._http.put(requestUrl, client);
  }
}
