import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44322',
  redirectUri: baseUrl,
  clientId: 'RickAndMortyApi_Angular',
  responseType: 'code',
  scope:
    'offline_access openid profile email phone AuthServer IdentityService AdministrationService SaasService ProductService',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'RickAndMortyApi',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44325',
      rootNamespace: 'RickAndMortyApi',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
    ProductService: {
      url: 'https://localhost:44325',
      rootNamespace: 'RickAndMortyApi',
    },
  },
} as Environment;
