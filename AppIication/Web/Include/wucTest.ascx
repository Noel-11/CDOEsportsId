<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucTest.ascx.vb" Inherits="Include_wucTest" %>
<asp:Table runat="server" ID="tblFormContent" SkinID="tblFormContent">
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3"></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:HiddenField runat="server" ID="hfClaimId"></asp:HiddenField>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Health Care Provider : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:DropDownList runat="server" ID="ddlHCP" SkinID="ddlInputForm">
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="PHIC ID : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtPhicId" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvPhicId" runat="server" ControlToValidate="txtPhicId" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Member : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            (Last Name)
            <asp:TextBox runat="server" ID="txtMemberLname" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvMemberLname" runat="server" ControlToValidate="txtMemberLname" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" />
            &nbsp;(First Name)
            <asp:TextBox runat="server" ID="txtMemberFname" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvMemberFname" runat="server" ControlToValidate="txtMemberFname" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" />
            &nbsp;(Middle Name)<asp:TextBox runat="server" ID="txtMemberMname" SkinID="txtInputForm"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Patient Last Name : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtPatientLname" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvPatientLname" runat="server" ControlToValidate="txtPatientLname" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Patient First Name : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtPatientFname" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvPatientFname" runat="server" ControlToValidate="txtPatientFname" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Patient Middle Name : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtPatientMname" SkinID="txtInputForm"></asp:TextBox></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Confined From : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <BDP:BasicDatePicker runat="server" ID="bdpConfinedFrom" TextBoxStyle-CssClass="bdpDate"
                ReadOnly="true" DateFormat="MMMM dd, yyyy" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Confined To : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <BDP:BasicDatePicker runat="server" ID="bdpConfinedTo" TextBoxStyle-CssClass="bdpDate"
                ReadOnly="true" DateFormat="MMMM dd, yyyy" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Diagnoses : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtDiagnoses" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvDiagnoses" runat="server" ControlToValidate="txtDiagnoses" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Diagnoses Amount : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtDiagnosesAmt" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvDiagnosesAmt" runat="server" ControlToValidate="txtDiagnosesAmt" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="HCP Charges Amount : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtHospChargesAmt" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvHospChargesAmt" runat="server" ControlToValidate="txtHospChargesAmt" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Professional Fee Amount : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:TextBox runat="server" ID="txtDocChargesAmt" SkinID="txtInputForm"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvDocChargesAmt" runat="server" ControlToValidate="txtDocChargesAmt" SetFocusOnError="true"
                Font-Bold="true" Font-Size="13pt" Display="Static" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell SkinID="celFormLabel3" Text="Claim Type : "></asp:TableCell>
        <asp:TableCell SkinID="celFormLabel2">
            <asp:DropDownList runat="server" ID="ddlClaimType" SkinID="ddlInputForm">
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
