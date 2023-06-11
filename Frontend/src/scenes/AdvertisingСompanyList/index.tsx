import { Box, useTheme } from "@mui/material";
import { DataGrid, GridColDef, GridRowParams, GridToolbar, GridValueFormatterParams } from "@mui/x-data-grid";
import { AdvertisingСompany, RepairOrder } from "../../Type";
import { tokens } from "../../theme";
import { string } from "yup";
import { useEffect, useState } from "react";
import dataProvider from "../../providers/dataProvider";
import Header from "../../components/Header";
import { AdvertisingСompanyChangeModal } from "../AdvertisingСompanyChange";


const AdvertisingСompanyList: React.FC = () => {
    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    const handleRowDoubleClick = (params: GridRowParams) => {
        const rowData: AdvertisingСompany = params.row as AdvertisingСompany;
        setCurrentCompany(rowData);
        console.log('Selected Row Data:', rowData);
        setOpen(true);
    };
    const [open, setOpen] = useState(false);
    const [currentCompany, setCurrentCompany] = useState<AdvertisingСompany>();
    const _theme = useTheme();
    const colors = tokens(_theme.palette.mode);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [advertisingСompany, SetAdvertisingСompany] = useState<AdvertisingСompany[]>([]);
    const columns: GridColDef<AdvertisingСompany>[] = [
        { field: "id", headerName: "ID" },
        { field: "name", headerName: "Наименование" },
        { field: "description", headerName: "Описание" },
        { field: "code", headerName: "Промо-код" },
        { field: "discount", headerName: "Скидка" },
        { field: "repairOrders", headerName: "Статистика", valueFormatter: repairOrderStatisticFormmater }
    ]
    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await dataProvider.getList<AdvertisingСompany>('AdvertisingСompany');
                SetAdvertisingСompany(data.data||[]);
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
            <Header title="Рекламные компнаии" subtitle="Список рекламных компаний" />
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
                    <DataGrid rows={advertisingСompany} 
                    columns={columns} 
                    slots={{ toolbar: GridToolbar }}  
                    onRowDoubleClick={handleRowDoubleClick}  />
                    <AdvertisingСompanyChangeModal order={currentCompany} open={open} handleClose={handleClose}/>
                </Box>
            )}
        </Box>
    );
}
const repairOrderStatisticFormmater = (params: GridValueFormatterParams<RepairOrder[]>): number => {
    return params.value? params.value.length:0;
}

export default AdvertisingСompanyList;