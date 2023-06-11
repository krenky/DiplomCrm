import * as React from 'react';
import { DataGrid, GridColDef, GridRowParams, GridToolbar, GridValueFormatterParams } from '@mui/x-data-grid';
import { tokens } from '../../theme';
import { Box, IconButton, useTheme } from '@mui/material';
import { ApplicationUser, Customer, Device, RepairOrder, SalesStages } from '../../Type';
import { useEffect, useState } from 'react';
import dataProvider from '../../providers/dataProvider';
import Header from '../../components/Header';
import { ModalForm } from '../form';
import AddIcon from '@mui/icons-material/Add';
import RepairOrderModal from '../repairOrderModal';

const RepairOrdersList: React.FC = () => {

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const [open, setOpen] = React.useState(false);

    //const nullArray: ApplicationUser[] = [];
    const _theme = useTheme();
    const colors = tokens(_theme.palette.mode);
    const columns: GridColDef<RepairOrder>[] = [
        { field: "Id", headerName: "ID" },
        { field: "customer", headerName: "Имя клиента", valueFormatter: customerValueFormatter },
        { field: "salesStages", headerName: "Этап продажи", valueFormatter: salesStagesValueFormatter },
        { field: "description", headerName: "Комментарий" },
        { field: "created", headerName: "Дата создания" },
        { field: "updated", headerName: "Дата обновления" },
        { field: "device", headerName: "Наименование устройства", valueFormatter: deviceValueFormatter },
        { field: "price", headerName: "Сумма" },
        { field: "applicationUser", headerName: "Имя менеджера", valueFormatter: applicationUserValueFormatter },
        { field: "isWithLoyaltyDiscount", headerName: "Скидка", valueFormatter: loyalityDiscountFormatter },
        // {
        //     field: "userName",
        //     headerName: "Имя сотрудника",
        //     flex: 1,
        //     cellClassName: "name-column--cell"
        // },
        // {
        //     field: "email", headerName: "Почта",
        //     flex: 1,
        // },
        // {
        //     field: "phoneNumber", headerName: "Номер телефона",
        //     flex: 1,
        // },
    ];
    const [users, setUsers] = useState<RepairOrder[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [currentOrder, setCurrentOrder] = useState<RepairOrder>();

    const handleRowDoubleClick = (params: GridRowParams) => {
        const rowData: RepairOrder = params.row as RepairOrder;
        setCurrentOrder(rowData);
        console.log('Selected Row Data:', rowData);
        setOpen(true);
        //document.location = 'http://localhost:5173/repairorders/' + rowData.id;
        // Perform further operations with the selected row data
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await dataProvider.getList<RepairOrder>('RepairOrdersList');
                setUsers(data.data || []);
            } catch (error) {
                console.error(error);
            } finally {
                setIsLoading(false);
            }
        };

        fetchData();
    }, []);

    return (
        <Box m={"20px"}>
            <Header title="Заявки" subtitle="Список заявок" />
            {/* <Box display="flex" flex={1}>
                <IconButton onClick={handleClickOpen}>
                    <AddIcon />
                </IconButton>
                <ModalForm open={open} handleClose={handleClose} />
            </Box> */}
            {isLoading ? (
                <div>Loading...</div>
            ) : (
                <Box
                    m={"40px 0 0 0"}
                    height="75vh"
                    sx={{
                        "& .MuiDataGrid-root": {
                            border: "none",
                        },
                        "& .MuiDataGrid-cell": {
                            borderBottom: "none",
                        },
                        "& .name-column--cell": {
                            color: colors.greenAccent[300],
                        },
                        "& .MuiDataGrid-columnHeaders": {
                            backgroundColor: colors.blueAccent[700],
                            borderBottom: "none",
                        },
                        "& .MuiDataGrid-virtualScroller": {
                            backgroundColor: colors.primary[400],
                        },
                        "& .MuiDataGrid-footerContainer": {
                            borderTop: "none",
                            backgroundColor: colors.blueAccent[700],
                        },
                        "& .MuiCheckbox-root": {
                            color: `${colors.greenAccent[200]} !important`,
                        },
                        "& .MuiDataGrid-toolbarContainer": {
                            backgroundColor: colors.blueAccent[500],
                            colorScheme: colors
                        }
                    }}
                >
                    <DataGrid rows={users} columns={columns} slots={{ toolbar: GridToolbar }} onRowDoubleClick={handleRowDoubleClick} />
                    <RepairOrderModal order={currentOrder} open={open} handleClose={handleClose} />
                </Box>
            )}
        </Box>
    );
}

export const salesStagesValueFormatter = (params: GridValueFormatterParams<SalesStages>): string => {
    return `${params.value.name}`;
};

export const deviceValueFormatter = (params: GridValueFormatterParams<Device>): string => {
    return `${params.value.name}`;
};

export const applicationUserValueFormatter = (params: GridValueFormatterParams<ApplicationUser>): string => {
    return `${params.value ? params.value.userName : ""}`;
};

export const customerValueFormatter = (params: GridValueFormatterParams<Customer>): string => {
    return `${params.value.firstName} ${params.value.lastName}`;
};

export const loyalityDiscountFormatter = (params: GridValueFormatterParams<boolean>): string => {
    if (params.value)
        return 'Да'
    else
        return 'Нет'
};

export default RepairOrdersList;