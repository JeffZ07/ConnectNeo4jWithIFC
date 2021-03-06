#ifndef COIN_SOGUIRADIOGROUP_H
#define COIN_SOGUIRADIOGROUP_H

// src\Inventor\Win\engines\SoGuiRadioGroup.h.  Generated from RadioGroup.h.in by configure.

/**************************************************************************\
 * Copyright (c) Kongsberg Oil & Gas Technologies AS
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are
 * met:
 * 
 * Redistributions of source code must retain the above copyright notice,
 * this list of conditions and the following disclaimer.
 * 
 * Redistributions in binary form must reproduce the above copyright
 * notice, this list of conditions and the following disclaimer in the
 * documentation and/or other materials provided with the distribution.
 * 
 * Neither the name of the copyright holder nor the names of its
 * contributors may be used to endorse or promote products derived from
 * this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
 * A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
 * HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
\**************************************************************************/

#ifndef SOWIN_INTERNAL
#error this is a private header file
#endif // !SOWIN_INTERNAL

#include <Inventor/fields/SoSFBool.h>
#include <Inventor/engines/SoSubEngine.h>
#ifdef __COIN__
#include <Inventor/engines/SoEngineOutput.h>
#endif // __COIN__
#include <Inventor/engines/SoEngine.h>

class SoGuiRadioGroup : public SoEngine {
  typedef SoEngine inherited;
  SO_ENGINE_HEADER(SoGuiRadioGroup);

public:
  static void initClass(void);
  SoGuiRadioGroup(void);

  SoSFBool in0;
  SoSFBool in1;
  SoSFBool in2;
  SoSFBool in3;
  SoSFBool in4;
  SoSFBool in5;
  SoSFBool in6;
  SoSFBool in7;

  SoEngineOutput out0;
  SoEngineOutput out1;
  SoEngineOutput out2;
  SoEngineOutput out3;
  SoEngineOutput out4;
  SoEngineOutput out5;
  SoEngineOutput out6;
  SoEngineOutput out7;

protected:
  virtual ~SoGuiRadioGroup(void);

private:
  virtual void inputChanged(SoField * which);
  virtual void evaluate(void);

  int index;
};

#endif // !COIN_SOGUIRADIOGROUP_H
