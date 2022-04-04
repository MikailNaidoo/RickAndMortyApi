import type { CharacterDto,AllCharactersDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CharacterService {
  apiName = 'CharacterService';

  get = (id: number) =>
    this.restService.request<any, CharacterDto>({
      method: 'GET',
      url: `/api/character-service/characters/${id}`,
    },
    { apiName: this.apiName });

  getList = () =>
    this.restService.request<any, AllCharactersDto>({
      method: 'GET',
      url: `/api/product-service/products`
        },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
