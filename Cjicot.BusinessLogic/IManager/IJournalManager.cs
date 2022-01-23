﻿using Cjicot.Presentation.DTO;
using Cjicot.Presentation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.IManager
{
    public interface IJournalManager
    {
        JournalUploadEnum UploadJournalManuscript(UploadJournalsDto request);
    }
}