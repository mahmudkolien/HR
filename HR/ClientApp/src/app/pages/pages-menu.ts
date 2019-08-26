import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Dashboard',
    icon: 'home-outline',
    link: '/pages/dashboard',
    home: true,
  },
  {
    title: 'FEATURES',
    group: true,
  },
  {
    title: 'User',
    icon: 'people-outline',
    link: '/pages/user',
  },
  {
    title: 'Company',
    icon: 'npm-outline',
    link: '/pages/company',
  },
  {
    title: 'Branch',
    icon: 'pantone-outline',
    link: '/pages/branch',
  },
  {
    title: 'Department',
    icon: 'smartphone-outline',
    link: '/pages/department',
  },

  {
    title: 'Miscellaneous',
    icon: 'shuffle-2-outline',
    children: [
      {
        title: '404',
        link: '/pages/miscellaneous/404',
      },
    ],
  },
];
