import './App.css'
import { ColorModeContext, useMode } from './theme'
import { CssBaseline, ThemeProvider } from "@mui/material";
import Topbar from './scenes/global/Topbar'
import { Route, Routes } from 'react-router-dom'
import Dashboard from './scenes/dashboard'
import SideBar from './scenes/global/Sidebar'
import Team from './scenes/team'
import Form from './scenes/form';
import Calendar from './scenes/calendar';
import GenericKanban from './scenes/kanban';
import RepairOrderForRouteView, { RepairOrderFormik } from './scenes/repairOrder';
import CustomerList from './scenes/customer';
import RegisterCustomer from './scenes/registerCustomer/indes';
import InventoryList from './scenes/Inventory'
import InventoryAdd from './scenes/InventoryForm';
// import RepairOrder from './scenes/repairOrder'
// import Customer from './scenes/customer'
// import InventoryItem from './scenes/inventoryItem'

function App() {
  const [theme, colorMode] = useMode();

  return (
    <ColorModeContext.Provider value={colorMode} >
      <ThemeProvider theme={theme} >
        <CssBaseline />
        <div className='app'>
          <SideBar />
          <main className='content'>
            <Topbar />

            <Routes>
              <Route path='/' element={<Dashboard />} />
              <Route path='/team' element={<Team />} />
              <Route path='/team/add' element={<Form />} />
              <Route path='/calendar' element={<Calendar />} />
              <Route path='/repairorders' element={<GenericKanban />}/>
              <Route path='/repairorders/:id' element={<RepairOrderFormik/>}/>
              <Route path='/сustomers' element={<CustomerList />}/>
              <Route path='/сustomers/add' element={<RegisterCustomer />}/>
              <Route path='/Inventory' element={<InventoryList />}/>
              <Route path='/Inventory/add' element={<InventoryAdd />}/>
            </Routes>
          </main>
        </div>
      </ThemeProvider>
    </ColorModeContext.Provider>
  );
}

export default App
