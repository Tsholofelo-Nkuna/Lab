import { Injectable, isDevMode } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  public apiBaseUrl = "";
  constructor() {
    if(isDevMode()){
      this.apiBaseUrl = "https://localhost:7124";
    }
    else{

    }
  }
}
