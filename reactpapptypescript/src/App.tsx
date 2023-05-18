import * as React from 'react';
import { Admin, Resource, ListGuesser, defaultTheme } from 'react-admin';
import  dataProvider from './providers/dataProvider';
import authProvider from './providers/authProvider';
//import { authProvider } from './authProvider';
import Layout from './Layout';
import contacts from './contacts';
import companies from './companies';
import deals from './deals';
import { Dashboard } from './dashboard/Dashboard';
import customers from './customers';
import CustomersList from './customers/CustomerList';

// const App = () => (
//     <Admin
//         dataProvider={dataProvider}
//         authProvider={authProvider}
//         layout={Layout}
//         dashboard={Dashboard}
//         theme={{
//             ...defaultTheme,
//             palette: {
//                 background: {
//                     default: '#fafafb',
//                 },
//             },
//         }}
//         requireAuth
//     >
//         <Resource name='customers' {...customers}/>
//         <Resource name="deals" {...deals} />
//         <Resource name="contacts" {...contacts} />
//         <Resource name="companies" {...companies} />
//         <Resource name="contactNotes" />
//         <Resource name="dealNotes" />
//         <Resource name="tasks" list={ListGuesser} />
//         <Resource name="sales" list={ListGuesser} />
//         <Resource name="tags" list={ListGuesser} />
//     </Admin>
//);

const App: React.FC = () => {
    return (
      <Admin dataProvider={dataProvider}>
        <Resource name="customers" list={CustomersList} />
      </Admin>
    );
  };

export default App;
