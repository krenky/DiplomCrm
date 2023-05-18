import * as React from 'react';
import {
  List,
  Datagrid,
  TextField,
  EmailField,
  DateField,
} from 'react-admin';

function CustomersList(){
  return (
    <List title="Customers" resource="customers" perPage={10}
    sort={{ field: 'Id', order: 'ASC' }}>
      <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="firstName" />
            <TextField source="lastName" />
            <TextField source="phone" />
            <EmailField source="email" />
            <TextField source="address" />
            <DateField source="birthdate" />
            <TextField source="repairOrders" />
        </Datagrid>
    </List>
  );
};

export default CustomersList;
