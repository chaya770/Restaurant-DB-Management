using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BE
{
        static class Tools
        {
            public static string ToStringProperty<T>(this T t)
            {
                string str = "";
                foreach (PropertyInfo item in t.GetType().GetProperties())
                    str += "\n" + item.Name + ": " + item.GetValue(t, null);
                return str;
            }
        }

}


/*
<UserControl x:Class="UI_WPF.OrderedDishTemplateUserControl"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:UI_WPF"
             xmlns:BE="clr-namespace:BE;assembly=BE"
             mc:Ignorable="d" d:DesignWidth="300" Height="143.387">
    <Grid d:DataContext="{d:DesignInstance BE:Ordered_Dish }" Background="BlanchedAlmond">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width = "5*" />
            < ColumnDefinition Width="7*"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height = "auto" />
            < RowDefinition Height="auto"/>
        </Grid.RowDefinitions>
        <TextBlock x:Name="OrderNumber" Width="100" Height="100"
              Text="{Binding orderNumber, Mode=OneTime}" />


        <TextBlock x:Name="dishNuber" Margin="5" Grid.Column="1"
                 Text="{Binding Path=dishNumber}"/>

        <TextBlock Margin = "5" Grid.Column="1" Grid.Row="1"
                 Text="{Binding Path=amountOfDish}"/>


    </Grid>
</UserControl>
*/