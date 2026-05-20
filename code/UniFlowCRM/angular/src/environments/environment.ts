import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44308/',
  redirectUri: baseUrl,
  clientId: 'UniFlowCRM_App',
  responseType: 'code',
  scope: 'offline_access UniFlowCRM',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'UniFlowCRM',
    // logoUrl: '/assets/images/logo.png',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44308',
      rootNamespace: 'UniFlowCRM',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
