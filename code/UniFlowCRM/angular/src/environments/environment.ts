import { Environment } from '@abp/ng.core';

const baseUrl = 'https://www.uniflowcrm.dz';

const oAuthConfig = {
  issuer: 'https://backend.uniflowcrm.dz:8443/',
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
      url: 'https://backend.uniflowcrm.dz:8443/',
      rootNamespace: 'UniFlowCRM',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
