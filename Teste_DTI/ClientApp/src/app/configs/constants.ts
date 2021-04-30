import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class Constants {
  public readonly API_ENDPOINT: string = environment.API_ENDPOINT;
}
