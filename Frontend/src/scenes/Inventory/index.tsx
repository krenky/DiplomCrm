import { Box, Button, IconButton, useTheme } from "@mui/material"
import { tokens } from "../../theme";
import Header from "../../components/Header";
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { ApplicationUser, InventoryItem } from "../../Type";
import { DataProvider } from '../../providers/dataProvider';
import { useEffect, useState } from "react";
import AddIcon from '@mui/icons-material/Add';
import Form from "../InventoryForm";
import React from "react";
import {ModalForm} from '../InventoryForm/index'




const InventoryList: React.FC = () => {

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const [open, setOpen] = React.useState(false);

    const nullArray: InventoryItem[] = [];
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const columns: GridColDef<InventoryItem>[] = [
        {
            field: "name",
            headerName: "Название",
            flex: 1,
            cellClassName: "name-column--cell"
        },
        {
            field: "description",
            headerName: "Описание",
            flex: 1,
            cellClassName: "name-column--cell"
        },
        {
            field: "price", 
            headerName: "Цена (руб.)",
            flex: 1,
        },
        {
            field: "picture", 
            headerName: "Фото",
            flex: 1,
        },
        {
            field: "quantityInStock", 
            headerName: "Остаток",
            flex: 1,
        },
    ];
    const dataProvider = new DataProvider('https://localhost:7270/api');

    const [users, setUsers] = useState<InventoryItem[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await dataProvider.getList<InventoryItem>('InventoryItems');
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
            <Header title="Материалы" subtitle="на складе" />
            <Box display="flex" flex={1}>
                <IconButton onClick={handleClickOpen}>
                    <AddIcon />
                </IconButton>
                <ModalForm open={open} handleClose={handleClose} />
            </Box>
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
                    }}
                >
                    <DataGrid rows={users} columns={columns} />
                </Box>
            )}
        </Box>
    );
}

export default InventoryList