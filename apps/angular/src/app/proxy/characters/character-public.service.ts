import type { CharacterDto,AllCharactersDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CharacterPublicService {
  apiName = 'CharacterService';

  getList = () =>
    this.restService.request<any, CharacterDto[]>({
      method: 'GET',
      url: `/api/character-service/characters`,
    },
    { apiName: this.apiName });

    get = (id: number) =>
        this.restService.request<any, CharacterDto>({
                method: 'GET',
                url: `/api/character-service/characters/${id}`,
            },
            { apiName: this.apiName });


    constructor(private restService: RestService) {}
}
